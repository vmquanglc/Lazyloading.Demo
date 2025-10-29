@echo off
echo Building Angular app locally...
call npm run build:prod
if %errorlevel% neq 0 (
    echo Build failed!
    pause
    exit /b %errorlevel%
)

echo.
echo Building Docker image...
docker build -t demo-angular:latest -f Dockerfile.local .
if %errorlevel% neq 0 (
    echo Docker build failed!
    pause
    exit /b %errorlevel%
)

echo.
echo Build completed successfully!
echo Image name: demo-angular:latest
pause
