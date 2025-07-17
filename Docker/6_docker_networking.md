
# 🌐 Docker Networking 101

Docker networking allows containers to communicate with each other, the host system, and external networks. This guide covers key concepts, network types, and common use cases.

---

## 🧾 Key Concepts

### 🕸️ Container Network
- A virtual network where Docker containers can communicate.
- Each container gets a unique IP address in this network.

### 📦 Network Driver
- Defines how Docker manages networking.
- Types: `bridge`, `host`, `none`, `overlay`, `macvlan`

---

## 🔌 Default Network Drivers

### 🔹 Bridge (default for standalone containers)
- Isolated network on the host machine.
- Containers can communicate using container names.
- Example:
  ```bash
  docker run --name app1 --network my-bridge-net my-image
  ```

### 🔹 Host
- Container shares the host's network namespace.
- Useful for performance or access to host services.
- Example:
  ```bash
  docker run --network host my-image
  ```

### 🔹 None
- Disables all networking for the container.
- Useful for security/isolation.

### 🔹 Overlay (Swarm only)
- Enables communication between containers across multiple Docker hosts.
- Used in distributed applications.

### 🔹 Macvlan
- Assigns MAC address to container, making it appear as a physical device on the network.
- Useful for low-level network integration.

---

## 🔧 Creating a Custom Bridge Network

```bash
docker network create my-custom-net
```

```bash
docker run --network my-custom-net --name container1 my-image
docker run --network my-custom-net --name container2 my-image
```

Containers can now communicate via names: `ping container2`

---

## 🧠 Use Cases

| Use Case                       | Recommended Network Type |
| ------------------------------ | ------------------------ |
| Isolated app communication     | Bridge                   |
| High-performance networking    | Host                     |
| No network access (sandboxing) | None                     |
| Multi-host Swarm deployments   | Overlay                  |
| Direct LAN integration         | Macvlan                  |

---

## 🛠️ Networking Commands

- List networks:
  ```bash
  docker network ls
  ```

- Inspect a network:
  ```bash
  docker network inspect my-custom-net
  ```

- Remove a network:
  ```bash
  docker network rm my-custom-net
  ```

---

## ✅ Summary

- Docker provides multiple networking options for different use cases.
- Use **bridge** for general container communication.
- Use **host** for speed and native host access.
- Use **overlay** for multi-host networks in Swarm mode.
- Docker networking is flexible and powerful — choose the right driver for your architecture.
