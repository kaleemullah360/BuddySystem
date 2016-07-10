#! /bin/sh
################################################################################
# 1. This script install Mono dmcs v 4.0.0.                                    #
# 2. Install & setup Mono in order to run Buddy System                         #
#                                                                              #
# Written By:                                                                  #
#  Kaleem Ullah <mscs14059@itu.edu.pk> <kaleemullah360@live.com>               #
################################################################################

# Download & Setup Mono
read -p "Want me to setup Mono-dmcs? (y/n)" -n 1 -r
echo    # (optional) move to a new line
if [[ $REPLY =~ ^[Yy]$ ]]
then
	sudo apt-get install mono-dmcs
	echo "Mono Succefully Installed."
	
	echo 
	echo "Now Installing dependancies.."
	echo
	echo "Please Wait it will take a while."
	sudo apt-get install mono-reference-assemblies-2.0 mono-devel
	sudo apt-get install libmono-corlib4.5-cil
	echo
	echo "Succefully Installed."
	echo "Compile: dmcs program.cs"
	echo
	echo "Run ./program.exe"
fi
