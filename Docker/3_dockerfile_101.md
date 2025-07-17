
# 🐳 Dockerfile 101

A Dockerfile is a script containing a series of instructions on how to build a Docker image. This file is the foundation for creating consistent, repeatable builds in Docker.

---

## 📄 Basic Structure

```Dockerfile
# Base image
FROM node:18

# Set working directory
WORKDIR /app

# Copy files
COPY package.json .

# Install dependencies
RUN npm install

# Copy rest of the source code
COPY . .

# Define default command
CMD ["node", "index.js"]
```

---

## 🧱 Common Instructions

- `FROM` – Specifies the base image.
- `WORKDIR` – Sets the working directory inside the container.
- `COPY` – Copies files from host to container.
- `ADD` – Like `COPY`, but can also extract archives and fetch URLs.
- `RUN` – Executes commands during image build (e.g., installing software).
- `CMD` – Default command to run when container starts.
- `ENTRYPOINT` – Similar to CMD, but harder to override.
- `EXPOSE` – Documents which port the container will listen on (does not publish).
- `ENV` – Sets environment variables.

---

## 🛠️ Build a Docker Image

```bash
docker build -t my-app .
```

- `-t` assigns a name and optionally a tag.
- `.` tells Docker to look for the Dockerfile in the current directory.

---

## 🚀 Run the Container

```bash
docker run -p 3000:3000 my-app
```

- `-p` maps host port to container port.

---

## 📌 Tips

- Use `.dockerignore` to exclude files from the build context.
- Combine `RUN` statements to reduce image layers.
- Always pin base images (`node:18`, not just `node`).
- Keep Dockerfiles readable and modular.

---

## ✅ Summary

A Dockerfile automates the image creation process. Mastering it allows you to build reproducible and efficient environments for your applications.
