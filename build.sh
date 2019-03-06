echo "Build script started"
echo

# Gateway
echo "STARTED Building Gateway Docker image"
docker build -t nexus:8082/msp-gateway -f Dockerfile.Gateway .
echo "FINISHED Building Gateway Docker image"

echo "STARTED Pushing Gateway Docker image to Nexus"
docker push nexus:8082/msp-gateway
echo "FINISHED Pushing Gateway Docker image to Nexus"

# Apple
echo "STARTED Building Apple Docker image"
docker build -t nexus:8082/msp-apple -f Dockerfile.Apple .
echo "FINISHED Building Apple Docker image"

echo "STARTED Pushing Apple Docker image to Nexus"
docker push nexus:8082/msp-apple
echo "FINISHED Pushing Apple Docker image to Nexus"

# Apple
echo "STARTED Building Mango Docker image"
docker build -t nexus:8082/msp-mango -f Dockerfile.Mango .
echo "FINISHED Building Mango Docker image"

echo "STARTED Pushing Mango Docker image to Nexus"
docker push nexus:8082/msp-mango
echo "FINISHED Pushing Mango Docker image to Nexus"

echo 
echo "Build script finished"
