# README


The Project contains various low level utility tools developed by me for adhoc usage. It is a place where I can store correctly workingcode to copy/paste later code.


## AppLogger
Applogger creates logs using log4net library.

Note: You also need to change file Properties -> AssemblyInfo.cs as well

## CliReader
It is used to read argument from commandline. It uses CommandLineArgumentsParser nuget package

## Configuration
This project reads config from a .config file or (any xml file for that matter)

The ease-of-use here is in mapping text file to C# object code.

## Cryptography 
This is NOT a production grade code. Use it at your own risk. 
That being said for fun coding, you can use it to encrupt messages.

## Poc_SignalR
A PoC to use SignalR with Asp.Net MVC

## Templating
This project creates messages from .cshtml templates. It uses custom razoe engine for tempalting. 

The beauty of razor templating is you don't need to build code after editing templates.

## YamlReader

A project to read yaml file and create C# objects.  I ran into issue and gave up on the idea. I switched to xml because XML and JSON are the only serious option and JSON is meant for machines, not human. 

---

# LICENSE
 MIT License