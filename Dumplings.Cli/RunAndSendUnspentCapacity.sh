#!/bin/bash

# exit when any command fails
set -e

# Make sure to have 'Config.txt' in the same file as this script.
# The following variables need to be imported from the config file:

# RPCUSER & RPCPASSWD = RPC credentials for Bitcoin Kntos,

source Config.txt

echo "Syncronizing blockchain"
dotnet run -c Release -- UnspentCapacity --rpcuser=$RPCUSER --rpcpassword=$RPCPASSWD --outfolder=$UCOUTFOLDER --conn=$CONN --nowaitonexit --sync &>> /home/dumplings/Logs.txt

echo "Script Ended!"
