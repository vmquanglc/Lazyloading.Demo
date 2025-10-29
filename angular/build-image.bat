if exist dist (
    rmdir /s /q dist
)
docker pull nginx:alpine
call npm run build:prod
docker build -t demo-angular:latest -f Dockerfile.local .