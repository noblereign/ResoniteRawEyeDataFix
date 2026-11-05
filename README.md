# RawEyeDataFix

## No longer needed as of Resonite version 2026.11.5.80

A [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader) mod for [Resonite](https://resonite.com/) that fixes [issue #6573](https://github.com/Yellow-Dog-Man/Resonite-Issues/issues/6573).

It's very quick n' dirty, but it's basically a single line change from the original. It checks if the eye tracking source is actually active before using the data from it.

## Installation
1. Install [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader).
1. Place [RawEyeDataFix.dll](https://github.com/noblereign/ResoniteRawEyeDataFix/releases/latest/download/RawEyeDataFix.dll) into your `rml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\Resonite\rml_mods` for a default install. You can create it if it's missing, or if you launch the game once with ResoniteModLoader installed it will create this folder for you.
1. Start the game. If you want to verify that the mod is working you can check your Resonite logs.
