# Demoapp dotnet-angular
A webpage for drawing rectangle SVG figures and displaying their perimeter.

**Info**
- The initial dimensions of the SVG figure are taken from a JSON file.
- The user can resize the figure using the mouse.
- The perimeter of the figure is displayed near the figure.
- The JSON file is updated with the new dimensions after resizing.

Implemented by using Angular (frontend) and C# (for JSON saving through API).

# DemoApp
This is the UI part of the app implemented using angular.

# Project
This is the backend of the app written in .NET. Onion Architecture + Repository pattern is used in the project. 

# Getting Started
First you will need to run the backend so that it is up and running:

1. Open the project and run the app

The backend will automatically create TestDb database with Rectangle table.

To run the ui part of the application, you will need to have Node.js and npm installed on your machine.

1. Clone the repository to your local machine:
    git clone https://github.com/VahidDev/dotnet-angular.git
2. Install the dependencies:
    npm install
3. Start the development server:
    npm start

The application will be running at http://localhost:4200.

# Important
The dimensions of the rectangle are stored in the json file of the backend (Project/Presentation/Project.API/dimensions.json)
