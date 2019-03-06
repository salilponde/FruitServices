echo "Build script started"
echo

echo "STARTED Building Gateway Docker image"
docker build -t nexus:8082/msp-gateway -f Dockerfile.Gateway .
echo "FINISHED Building Gateway Docker image"

echo "STARTED Pushing Gateway Docker image to Nexus"
docker push nexus:8082/msp-gateway
echo "FINISHED Pushing Gateway Docker image to Nexus"

echo 
echo "Build script finished"
