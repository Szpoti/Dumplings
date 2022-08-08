cd ..
cd Dumplings.Cli/
rem Don't forget to replace username, password and xpub
dotnet run -c Release -- sync --rpcuser=user --rpcpassword=password --nowaitonexit
dotnet run -c Release -- WasabiCoordStats --xpub=xpub,xpub2 --outfolder="C:\Users\user\Desktop\Dumplings\WW1" --rpcuser=user --rpcpassword=password --nowaitonexit
dotnet run -c Release -- WabiSabiCoordStats --xpub=xpub --outfolder="C:\Users\user\Desktop\Dumplings\WW2" --rpcuser=user --rpcpassword=password