# VaM Plugin Template

Basic template for a VaM plugin. Includes `VaMLib`, my update to MacGruber's super helpful ui utils. Also includes a .csproj file that references the VaM libraries so that VSCode can give you intellisense for all the VaM classes and functions.

## Usage

Just clone this repo, delete the `.git/` directory, and `git init` a new repo for your plugin. You will have to update the `HintPath` of the `Reference`s in the .csproj file to point to your actual VaM installation. Any time you add a new .cs file it must also be added to the .csproj file and the .cslist file (note that .cslist is a specific file used for VaM plugins).

Don't forget to rename your plugin and your namespace.
