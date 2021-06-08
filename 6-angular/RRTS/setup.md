# Getting started with TS

## Get node installed in your machine

Use the link [node dl place](https://nodejs.org/en/) and get the stable version of node

## What is node.js

- interpreter/server environment for JS, so that you'll be able to run JS scripts outside of the browser
- comes with an engine that runs your script
- npm (the node package manager) to manage the packages and dependencies that you need in your JS project
- in a nutshell: node.js is an environment that helps in creating and managing JS projects

#### Note: To check if node is properly installed, run the command `node -v` on your cmd line

## Creating a TS project

1. Create a folder to store your project
2. Navigate into the folder and create a package.json file using the command `npm init -y`
   - What is a package.json file?
     - File that holds various metadata relevant to the project. use it to give info to package manager (npm) that allows it to identify the project as well as handle the project deps.
     - Note that project deps are stored in a folder called node modules. If this folder does not exist, you can reinstall all the project deps using the command `npm i`. This command looks into your package.json and sees what projects deps you have and it reinstalls it for you and puts it in the node modules folder
3. Run the command `npm i typescript --save-dev` to install ts and be able to work with it
   - you can also run the command `npm i typescript -g` to install it globally, this is a little buggy tho.
   - this is important because we want to dev with TS
4. In the pacakge.json file, configure the node script to compile with tsc (TS compiler)
   - in scripts include the key:value of "tsc":"tsc"
   - Running `tsc` locally will compile the closes project defined by a tsconfig.json, you can compile a set of TS files to JS
   - `tsc` is the TypeScript Compiler
   - tldr; cmd that you would use to compile your TS project
5. Run the command `tsc --init` to scaffold a tsconfig.json file
   - this command initializes a TS project
   - What is a tsconfig.json file?
     - specifies the root files and the compiler options required to compile the project
     - make sure to edit the tsconfig file to include a place to put the transpiled js in another folder, and to add in where the compiler will look for things to compile
6. Write your first .ts file!
   - really like js but with types
   - so in ts, the syntax is `name:type`
