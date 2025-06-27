# Sinqia API

### Build 
```bash
docker build -t sinqia-api -f ./src/Sinqia.Calculator.Api/Dockerfile .
```

```bash
docker run -d -p 8080:8080 --network sinqia-api --name sinqia-api sinqia-api
```
