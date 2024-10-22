# MinIO Console Application

## Project Description

This project provides a console application that integrates with MinIO, a high-performance object storage system. The application allows users to list, download, and upload files to a MinIO server set up using Docker. The aim is to provide a straightforward and efficient way to manage files on a MinIO server from a console application.

## Introduction
This console application is designed to interact with a MinIO server set up using Docker. It supports listing, downloading, and uploading files, providing a simple and efficient way to manage your object storage.

## Features
- List files in a MinIO bucket
- Download files from a MinIO bucket
- Upload files to a MinIO bucket

## Prerequisites
- Docker installed on your machine
- .NET Core SDK installed
- MinIO server set up using Docker

## Setup MinIO with Docker
1. **Pull the MinIO Docker image:**
   ```sh
   docker pull minio/minio
   ```

2. **Run the MinIO Docker container:**
   ```sh
   docker run -p 9000:9000 --name minio -v /mnt/data:/data -e "MINIO_ROOT_USER=minioadmin" -e "MINIO_ROOT_PASSWORD=minioadmin123" minio/minio server /data
   ```
   Replace `<YOUR-ACCESS-KEY>` and `<YOUR-SECRET-KEY>` with your desired MinIO access and secret keys.

2. **Failed Docker container:**
If you cannot install on the Docker side, create a folder named minio in the C directory and put the minioFiles/minio.env (https://github.com/beytullahbuyuktolu/MinIOAPI/blob/main/MinIOAPIAPP/minioFiles/minio.env ) file in the project and run the following command.
   ```sh
   docker run -dt -p 9000:9000 -p 9001:9001 -v C:\minio\data:/data -v C:\minio\minio.env:/etc/config.env -e "MINIO_CONFIG_ENV_FILE=/etc/config.env" --name "minio_local" minio/minio server /data --console-address ":9001"
   ```

4. **Access the MinIO web console:**
   Open your browser and navigate to `http://localhost:9001`. Log in using the access and secret keys you provided.

## Console Application Usage
1. **Clone the repository:**
   ```sh
   git clone https://github.com/beytullahbuyuktolu/MinIOAPI.git
   cd your-repo-name
   ```

2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

3. **Configure the application:**
   Update the `program.cs` file with your MinIO server configuration:
   endpointAddress,accessKey,secretKey,bucketName
   

