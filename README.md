🌐 Social App - Frontend
📖 Introduction
The Social App project represents the User Interface (Frontend) component of a full-featured social media application. It is built using the Angular framework and TypeScript to deliver a modern, fast, and highly interactive user experience, connecting to a separate Backend API.

The goal of this project is to showcase the ability to build complex Single Page Applications (SPAs), fully leveraging Angular's component-based architecture and robust state management techniques (e.g., RxJS).

✨ Key Features
User Authentication: Secure Sign-up, Sign-in, and Sign-out functionality (typically via JWT/Token).

Profile Management: View and edit personal information, profile pictures, and cover photos.

Content Posting: Allows users to publish text and/or media (image/video) content.

Dynamic Feed: Displays the latest posts from followed users in a real-time timeline.

Post Interactions: Functionality for Liking and Commenting on posts in real-time.

Social Connectivity: Ability to Follow and Unfollow other users.

🛠 Technologies Used
Frontend Framework: Angular

Language: TypeScript

State Management (Optional): RxJS (for asynchronous handling and data stream management)

UI/Styling: (Fill in the library you use, e.g., Angular Material, Bootstrap, SCSS)

Routing: Angular Router

🚀 Getting Started
Prerequisites
You need to have the following installed:

Node.js (LTS version recommended)

npm (or Yarn)

Angular CLI (Install globally: npm install -g @angular/cli)

Installation Steps
Clone Repository:

Bash

git clone https://github.com/nguyenchuongbep1310/social-app-angular.git
cd social-app-angular
Install Dependencies:

Bash

npm install
# or
yarn install
Environment Setup:

Open the environment file (e.g., src/environments/environment.ts).

Update the apiUrl variable to point to your Backend API endpoint.

TypeScript

export const environment = {
  production: false,
  apiUrl: 'YOUR_BACKEND_API_URL_HERE' // Example: 'http://localhost:5000/api'
};
Run the Application:

Bash

ng serve
The application will automatically open in your browser at: http://localhost:4200/.
