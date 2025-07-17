
# 💾 Docker Storage & Data Persistence

Understanding storage and persistence in Docker is essential for managing application data, especially for databases and stateful services. This guide covers key concepts, types of storage, and best practices.

---

## 🧾 Key Terminology

### 📦 Volumes
- Managed by Docker and stored in a part of the host filesystem.
- Best way to persist data across container restarts and rebuilds.
- Created with:
  ```bash
  docker volume create my-volume
  ```

### 📁 Bind Mounts
- Map a host directory or file into a container.
- Useful for development where live editing of files is needed.
- Example:
  ```bash
  docker run -v $(pwd):/app my-image
  ```

### 📂 tmpfs Mounts
- Temporary, in-memory storage.
- Fast but ephemeral — data disappears after container stops.
- Good for caching or sensitive data that shouldn't be stored on disk.

---

## 🛠️ Using Volumes in Containers

### Anonymous Volume
```bash
docker run -v /data my-image
```

### Named Volume
```bash
docker run -v my-volume:/data my-image
```

### Docker Compose Example
```yaml
services:
  db:
    image: postgres
    volumes:
      - pgdata:/var/lib/postgresql/data

volumes:
  pgdata:
```

---

## 📌 Why Use Volumes?

- **Persistence**: Keep data when containers are recreated.
- **Isolation**: Avoid polluting the host filesystem.
- **Performance**: Optimized by Docker for better I/O.
- **Portability**: Easy to migrate and back up data.

---

## 🧹 Managing Volumes

- List volumes:
  ```bash
  docker volume ls
  ```

- Inspect a volume:
  ```bash
  docker volume inspect my-volume
  ```

- Remove unused volumes:
  ```bash
  docker volume prune
  ```

---

## ✅ Summary

- Use **volumes** for persistent, managed data storage in Docker.
- Prefer **named volumes** for long-lived data.
- Use **bind mounts** for development and flexibility.
- Avoid storing data inside containers directly — it's not persistent.

Proper use of Docker storage options ensures your application data is safe, manageable, and portable.
