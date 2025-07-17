
# 🐳 Docker Image Tags, Layers & Caching Summary

A quick reference to understand how Docker images work under the hood, focusing on tagging, layering, and caching during image builds.

---

## 🏷️ Image Tags

- Tags are labels used to identify Docker images.
- Format: `repository:tag` (e.g., `nginx:1.25`)
- Default tag is `latest` if none is provided.
- Tags are mutable — `latest` can point to different image versions over time.

### Tagging Best Practices
- Use semantic versioning (`1.0`, `2.3.1`)
- Add environment-specific tags (`dev`, `prod`)
- Always pin tags in production to avoid unexpected changes

---

## 🧱 Image Layers

- Each instruction in a `Dockerfile` creates a new image layer.
- Layers are:
  - **Immutable** – cannot be modified after creation
  - **Reusable** – shared across multiple images if unchanged
  - **Stacked** – combined to build the final image

### Example
```Dockerfile
FROM node:18
COPY package.json .
RUN npm install
COPY . .
```
Each line creates a separate, cacheable layer.

---

## ⚡ Build Caching

- Docker uses layer caching to speed up builds.
- If a layer hasn’t changed, Docker reuses it from cache.
- Changes in earlier layers invalidate all subsequent ones.

### How It Works
- If `package.json` hasn’t changed, `npm install` can be skipped.
- If the base image or a copied file changes, caching is invalidated from that point onward.

---

## 💡 Caching Tips

- **Order Dockerfile commands wisely**:
  - Place commands that change less frequently (e.g., copying `package.json`) near the top.
- **Split COPY instructions**:
  - First copy only `package.json` and `package-lock.json` before running `npm install`.
- **Use `.dockerignore`**:
  - Exclude files like `.git`, `node_modules`, and logs to prevent unnecessary rebuilds.
- **Combine RUN commands**:
  - Minimize the number of layers with `&&`:
    ```Dockerfile
    RUN apt-get update && apt-get install -y curl
    ```

### Forcing a Cache Bust
To intentionally break the cache (useful in CI/CD or development):
```bash
docker build --build-arg CACHE_BREAK=$(date +%s) .
```

---

## ✅ Summary

- **Tags** help version and identify Docker images.
- **Layers** are immutable and stackable parts of an image built from each Dockerfile instruction.
- **Caching** improves build speed by reusing unchanged layers.
- Smart Dockerfile structure and use of `.dockerignore` can significantly optimize builds.
