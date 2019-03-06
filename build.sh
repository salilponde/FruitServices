echo "Build script started"
echo

echo "Building Gateway Docker image"
docker build -t nexus:8082/msp-gateway -f Dockerfile.Gateway
docker push nexus:8082/msp-gateway
echo "Finished building Gateway Docker image"

echo 
echo "Build script finished"
