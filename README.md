# Windows Authorization Test Project

This repository has a test project for ensuring Windows Authorization Scenarios work within Docker containers.

## Setup

1. Clone the project

2. Open the Project Solution and Run it in Debug using F5.

_Assuming your computer is on a Windows Domain your Domain and UserID should be shown in the header_

3. Using Docker for Windows you should be able to build and run the docker images.

```powershell
docker-compose up
```

This will 3 images and start 3 containers.

- Application Running hosted in Kestrel
  Image: `webauth:latest`  Name: `webauth_1`  http://<ComputerName>:8000

- Application Running hosted in IIS with DotNet Core Module and Windows Auth enabled
  Image: `webauth:iis`   Name: `webauth-iis_1`  http://<ComputerName>:8001

- Application Running hosted with HttpSys (formerly WebListener) and Windows Auth enabled
  Image: `webauth:httpsys`   Name: `webauth-httpsys-1`  http://<ComputerName>:8002

If the second two images are deployed to a server host that has been properly configured for Windows Authentication in Docker Containers using gMSA they should authenticate properly.

- Image:  `webauth:latest`  Name: `webauth_1`  --Application Running using Kestrel only.

- Image:  `webauth:iis`  Name: `webauth-iis_1`  --Application Running
