
# 🐳 Docker Compose 101

Docker Compose is a tool for defining and managing multi-container Docker applications using a YAML file. It simplifies the process of starting, stopping, and configuring services.

---

## 📄 Basic `docker-compose.yml` Structure

```yaml
version: "3.9"
services:
  web:
    image: nginx:latest
    ports:
      - "8080:80"

  app:
    build: .
    ports:
      - "3000:3000"
    volumes:
      - .:/app
    environment:
      - NODE_ENV=development

  db:
    image: postgres:15
    environment:
      POSTGRES_USER: user
      POSTGRES_PASSWORD: password
      POSTGRES_DB: mydb
    volumes:
      - db-data:/var/lib/postgresql/data

volumes:
  db-data:
```

---

## 🔧 Common Configuration Keys

- `services`: Define each containerized service.
- `build`: Path or context to Dockerfile.
- `image`: Image name (local or from a registry).
- `ports`: Map container ports to host.
- `volumes`: Mount host paths or named volumes.
- `environment`: Set environment variables.

---

## 🚀 Useful Commands

### Start Services
```bash
docker-compose up
```

### Start in Background
```bash
docker-compose up -d
```

### Stop and Remove Containers
```bash
docker-compose down
```

### Rebuild Services
```bash
docker-compose up --build
```

### View Logs
```bash
docker-compose logs -f
```

---

## 📌 Tips

- Use `.env` files to manage environment variables.
- Use named volumes for data persistence.
- Use service dependencies (`depends_on`) to define startup order.
- Compose is ideal for local dev and small app stacks.

---

## ✅ Summary

Docker Compose allows you to define multi-container applications in a single YAML file. It streamlines development workflows by managing all containers and their configuration together.

It's especially useful for local development, testing environments, and simple deployments.
