# Import libraries
library(eegUtils)
library(readxl)
library(reshape2)
library(readxl)
library(openxlsx)
library(zoo)
library(eegkit)

# Names of the 4 time events in the input data
# Note the input data from Emotiv has been exported to Excel. Recordings made using EmotivPRO can be exported to a .cvs file / converted to Excel
# https://emotiv.gitbook.io/emotivpro-v3/managing-your-eeg-data-recordings/exporting-an-eeg-data-recording
# list_sheet_names = c("baseline_open", "baseline_closed", "tutorial_video", "start_playing")

pw_calculation <- function(name)
{
  # Step 0: Create temporary Excel workbook
  temp_data <- createWorkbook()
  
  # Step 1: Import cleaned datasheet with the 4-time events
  for (x in list_sheet_names) {
    data <- read_excel(name, sheet = x)
    data_selected <- data[5:18] # Select 14 EEG channels; default Emotiv layout
    data_selected <- as.data.frame(data_selected) # Convert to data frame
    rm(data)
    
    # Step 2: Define filter coefficients according to Emotiv
    # https://web.archive.org/web/20250403222607/https://www.emotiv.com/tools/knowledge-base/research-information/how-are-band-powers-calculated
    b <- c(0.96588528974407006000, -1.93177057948814010000, 0.96588528974407006000)
    a <- c(1.00000000000000000000, -1.93060642721966810000, 0.93293473175661223000)
    
    # Step 3: Define band frequencies (Theta --> Gamma), following Emotiv’s spec
    band_indices <- list(
      Theta = 4:8, # Hz frequencies
      Alpha = 8:12, # Hz frequencies
      BetaL = 12:16, # Hz frequencies
      BetaH = 16:25, # Hz frequencies
      Gamma = 25:45 # Hz frequencies
    )
    
    # Step 4: Create filter function, first forward, then backwards with Emotiv’s coefficients
    filter_function <- function(col) {
      filter_forward <- signal::filter(b, a, col) # Use of signal:: duplicate function in eegUtils package
      filter_backward <- rev(signal::filter(b, a, rev(filter_forward)))
      return(filter_backward)
    }
    # Step 5: Apply filter function
    eeg_data_filtered <- as.data.frame(lapply(data_selected, filter_function))
    
    # Step 6: Define parameters according to Emotiv’s spec
    sampling_rate <- 256 # Hz
    epoch_length <- sampling_rate * 2 # 2 seconds window typically
    num_channels <- 14 # 18 channels with 4 reference
    
    # Number of epochs based on duration event divided by 2 seconds
    num_epochs <- as.integer(nrow(eeg_data_filtered) / epoch_length)
    
    # Step 7: Create an empty data frame to hold the epoch values
    band_powers_df <- data.frame(matrix(ncol = 0, nrow = num_epochs))
    61
    # Step 7: Loop over the epoch to calculate the band power values per electrode per epoch per band power
    (14 channels * 5 power band values * num_epochs)
    for (i in 1:num_epochs) {
      #i = 1
      start_index <- (i - 1) * epoch_length + 1
      end_index <- i * epoch_length
      
      # Filter the selected segment from the epoch
      segment <- eeg_data_filtered[start_index:end_index, ]
      
      # DC removal to denoise signal
      segment <- sweep(segment, 2, colMeans(segment), FUN = "-")
      
      # Apply Hanning window to the segment
      # Following Emotiv’s calculation
      hanning_window <- 0.5 * (1 - cos(2 * pi * (1:epoch_length) / (epoch_length + 1)))
      eeg_windowed <- segment * hanning_window
      
      # Fast Fourier Transform
      # eegkit fft produced the best results
      eeg_fft <- eegfft(as.matrix(eeg_windowed), Fs = 2) # Fs = 2 second time window
      
      # Normalize the results by diving the FFT by the length of the epoch
      # Following Emotiv’s spec
      eeg_fft_square <- abs(eeg_fft$strength)^2 / epoch_length
      
      # Create a temporary data frame to store the result
      temp <- data.frame(matrix(ncol = 0, nrow = 1)) # Create empty data frame for one epoch
      
      # Calculate the band values per channel, e.g, 5 power band values per channels (* 14)
      for (channel in colnames(segment)) {
        
        # Remove “EEG.” From the name to make the format compatible with code from dissertation
        remove_EEG <- sub("EEG\\.", "", channel)
        
        # Calculate band powers for the current channel
        band_powers_channel <- sapply(names(band_indices), function(band) {
          band_range <- band_indices[[band]]
          
          # Average across frequency band, common practice
          return(mean(eeg_fft_square[band_range, colnames(segment) == channel]))
        })
        
        # Add band power values to temp with correct column names
        for (band in names(band_indices)) {
          temp[[paste0("POW.", remove_EEG, ".", band)]] <- band_powers_channel[band]
        }
      }
      # Add the results horizontally to the main data frame, similar to Emotiv's output
      band_powers_data <- rbind(band_powers_data, temp)
    }
    
    # Add the power band data frame to the Excel sheet with the correct time event name
    addWorksheet(temp_data, x)
    
    # Write the data to the Excel sheet
    writeData(temp_data, x, band_powers_data)
  }
  
  #rm(a,b,band,band_powers_channel,Book_ID,channel,VR_ID,end_index,epoch_length,hanning_window,i,nu
  #m_channels,num_epochs,sampling_rate,start_index,band_indices,remove_EEG,data_selected,eeg_data_filter
  #ed,eeg_fft,eeg_fft_square,eeg_windowed,segment)
  
  #temp_name <- paste0(substr(name,0,3),"_output_VR.xlsx") # for the first 9 IDs
  #temp_name <- paste0(substr(name,0,4),"_output_VR.xlsx") # for the next 10 IDs, starting from 10
  #temp_name <- paste0(substr(name,0,4),"_output_Book.xlsx") # for the Book IDs
  saveWorkbook(temp_data, temp_name, overwrite = TRUE) # Save all the time event Excel sheets
}

# Call the function and apply it for all the X datasets (e.g., 19)
#for(i in VR_dataset[1:20])
#{
#  pw_calculation (i)
#}
