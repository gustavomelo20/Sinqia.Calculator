# Sinqia API

```bash
git clone https://github.com/gustavomelo20/Sinqia.Calculator.git
```

```bash
cd Sinqia.Calculator
```

### Build 
```bash
docker build -t sinqia-api -f ./src/Sinqia.Calculator.Api/Dockerfile .
```

```bash
docker network create sinqia-api
```

```bash
docker run -d -p 8080:8080 --network sinqia-api --name sinqia-api sinqia-api
```

```bash
http://localhost:8080/swagger/index.html
```