<h1 align="center">
  Integrating EEG Sensors with Virtual Reality to Support Students with ADHD
</h1>

<div align="center">
  <a href="https://www.youtube.com/watch?v=w-_Mpbzgaeo" target="_blank">
    <img src="https://img.youtube.com/vi/w-_Mpbzgaeo/maxresdefault.jpg" alt="VRADHD Video">
  </a>
  <p>▶ Click the image to watch the video on YouTube</p>
</div>


<h2>Overview</h2>
<p>
  This project provides an educational supply chain role play game, teaching the fundamentals of Supply Chain Management, and offers support for VR, desktop and mobile phones (Android/iOS). In addition, reference scripts for R are included to reverse engineer Emotiv's power-band calculation.

</p>

<h2>Requirements</h2>
<ul>
  <li><b>Windows PC:</b> Tested on Windows 10 22H2</li>
  <li><b>Virtual Reality:</b> Tested with a Meta Quest 3 VR headset</li>
  <li><b>SteamVR</b></li>
  <li><b>VRChat:</b> PC application or Android release (mobile phones/Meta headsets)</li>
  <li><b>VRChat account:</b> Registered account with publication rights</li>
  <li><b>VRChat Creater Companion:</b> Registered account with publication rights</li>
</ul>

<h2>Getting Started</h2>
<ol>
  <li>Clone the repository or download the .zip from the <> Green code button:<br>
    <code>git clone https://github.com/SCT-lab/VRADHD.git</code>
  </li>
  <li>Open <b>VRChat Creater Companion</b>, click <b>Create New Project → Add Existing Project</b>, and select the cloned project folder.</li>
  <li>Press <b>Manage Project</b> and make sure the required packages from VRChat are installed.</li>
</ol>

<h2>Unity Versions & Dependencies</h2>
<ul>
  <li><b>Operating System:</b> Windows 10 or 11</li>
  <li><b>Unity Versions:</b>
    <ul>
      <li><b>Windows PC:</b> Tested with Unity <code>2022.3.22f1</code></li>
    </ul>
  </li>
  <li><b>Required Unity Packages:</b>
    <ol>
	  <li>VRChat Package Resolver Tool (v0.1.27 or higher) – <a href="https://github.com/vrchat/packages" target="_blank">GitHub</a></li></li>
	  <li>VRChat SDK - Base (v3.5.0 or higher) – <a href="https://github.com/vrchat/packages" target="_blank">GitHub</a></li></li>
	  <li>VRChat SDK - Worlds (v3.5.0 or higher – <a href="https://github.com/vrchat/packages" target="_blank">GitHub</a></li></li>
      <li>Post Processing</li>
      <li>TextMeshPro</li>
	  <li>AI Navigation (v1.1.7 or higher)</li>
    </ol>
  </li>
</ul>

<h3>Included Scripts</h3>
<table border="1" cellpadding="8" cellspacing="0">
  <thead>
    <tr>
      <th>Script</th>
      <th>Description</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><b>Scripts/EEG_Band_Power_Emotiv_Reverse.cs</b></td>
	  <td>Reverse engineered Power Band calculations used for topographic heatmaps following Emotiv's specification.</td>
    </tr>
    <tr>
      <td><b>BullwhipIndex.cs</b></td>
      <td>Calculates and updates the bullwhip effect index based on player order and inventory data.</td>
    </tr>
    <tr>
      <td><b>ButtonNextStage.cs</b></td>
      <td>Advances the game to the next stage when the corresponding UI button is pressed.</td>
    </tr>
    <tr>
      <td><b>ButtonPressedSound.cs</b></td>
      <td>Plays an audio feedback sound whenever a UI button is clicked.</td>
    </tr>
    <tr>
      <td><b>ChangeVolumeSlider.cs</b></td>
      <td>Adjusts the global or target audio volume using a UI slider.</td>
    </tr>
    <tr>
      <td><b>EnablePracticeRound.cs</b></td>
      <td>Enables the practice round logic and related UI elements before the main gameplay starts.</td>
    </tr>
    <tr>
      <td><b>ExtraTime.cs</b></td>
      <td>Adds or manages additional time extensions during a game phase.</td>
    </tr>
    <tr>
      <td><b>Floating.cs</b></td>
      <td>Applies a smooth floating animation effect to objects or UI elements.</td>
    </tr>
    <tr>
      <td><b>GrabItem.cs</b></td>
      <td>Handles player interaction for grabbing and releasing in-game objects.</td>
    </tr>
    <tr>
      <td><b>InventoryValue.cs</b></td>
      <td>Tracks and updates the player’s current inventory values.</td>
    </tr>
    <tr>
      <td><b>MenuFadeInv.cs</b></td>
      <td>Controls fading transitions for inventory-related UI menus.</td>
    </tr>
    <tr>
      <td><b>NextStageButton.cs</b></td>
      <td>Triggers stage progression logic when the next-stage button is activated.</td>
    </tr>
    <tr>
      <td><b>OrderReceivedMenu.cs</b></td>
      <td>Displays and manages the UI showing received orders for the current round.</td>
    </tr>
    <tr>
      <td><b>Phase1Skip.cs</b></td>
      <td>Allows skipping of Phase 1 under specific conditions or user input.</td>
    </tr>
    <tr>
      <td><b>PlayerOrderUpdate.cs</b></td>
      <td>Processes and synchronizes player order data during gameplay.</td>
    </tr>
    <tr>
      <td><b>PracticeRoundEnable.cs</b></td>
      <td>Activates practice-round-specific rules, UI, and interactions.</td>
    </tr>
    <tr>
      <td><b>UpdateTextFirstTimeStageNumberDisplay.cs</b></td>
      <td>Updates stage number text display when a stage is shown for the first time.</td>
    </tr>
    <tr>
      <td><b>ShowAmountSendPlayerOrderUpdateScoreboardReset.cs</b></td>
      <td>Displays order amounts, sends player order updates, and resets the scoreboard.</td>
    </tr>
    <tr>
      <td><b>TriggerTextPromptElseTextPromptActors.cs</b></td>
      <td>Triggers contextual text prompts depending on game state or active actors.</td>
    </tr>
  </tbody>
</table>

<h2>Miscellaneous</h2>
<ol>
  <li>
    The project is technically compatible with major VR headsets (HTC, Meta/Oculus, Valve, WMR headsets).
  </li>
  <li>
    The game logic is written in UdonSharp (VRChat-specific), which is a variant of C#.
  </li>
    </ul>
  </li>
</ol>

<h2>Development Team</h2>
<p>Development by Juriaan Wolfers (WUR), project managed by Will Hurst (WUR) and Caspar Krampe (WUR).</p>

<h2>License</h2>
<p>
  Copyright © 2025 Wageningen University &amp; Research.
</p>

<p>
  This project is licensed under the <strong>MIT License</strong>. You are free to use, modify, and distribute this software and documentation, provided that the original copyright notice and this permission notice are included in all copies or substantial portions of the software.
</p>

<p align="center">
  <a href="./LICENSE" target="_blank">View full license text</a>
</p>

<hr>

<h2>Citation</h2>
<p>
If you use this code in your research, please cite:<br>
<b>Wolfers, J., Hurst, W. and Krampe, C., 2026.</b><i> Integrating EEG Sensors with Virtual Reality to Support Students with ADHD</i> - sensors<br>
<a href="" target="_blank">sensors</a>

</p>
