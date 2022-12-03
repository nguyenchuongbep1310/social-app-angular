FROM node:latest as build

# Set the working directory
WORKDIR /usr/src/app

COPY package.json package-lock.json ./
# Add the source code to app
# Install all the dependencies
RUN npm install
COPY . .
# Generate the build of the application
RUN npm run build


# Stage 2: Serve app with nginx server

# Use official nginx image as the base image
FROM nginx:latest
COPY nginx.conf /etc/nginx/nginx.conf
# Copy the build output to replace the default nginx contents.
COPY --from=build /usr/src/app/dist/ungap /usr/share/nginx/html

# Expose port 80
EXPOSE 80