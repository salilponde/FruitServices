#!/bin/bash -e

echo "Build script started"
echo

echo "Detecting changed microservices"
changed_folders=`git diff --name-only HEAD^ | grep / | awk 'BEGIN {FS="/"} {print $1}' | uniq`
echo "Changed folders: "$changed_folders

changed_services=()
for folder in $changed_folders
do
  if [ "$folder" == 'Common' ]; then
    echo "Common folder changed, building all microservices"
    changed_services=`find . -maxdepth 1 -type d -not -name 'Common' -not -name '.vs' -not -name '.git' -not -path '.' | sed 's|./||'`
    echo "List of microservices: "$changed_services
    break
  else
    echo "Adding $folder to list of microservices to build"
    changed_services+=("$folder")
  fi
done

for service in $changed_services
do
  case $service in
    Gateway)
	  echo "STARTED Building Gateway Docker image"
      docker build -t nexus:8082/msp-gateway -f Dockerfile.Gateway .
      echo "FINISHED Building Gateway Docker image"

      echo "STARTED Pushing Gateway Docker image to Nexus"
      docker push nexus:8082/msp-gateway
      echo "FINISHED Pushing Gateway Docker image to Nexus"
	  ;;

    Apple)
	  echo "STARTED Building Apple Docker image"
      docker build -t nexus:8082/msp-apple -f Dockerfile.Apple .
      echo "FINISHED Building Apple Docker image"

      echo "STARTED Pushing Apple Docker image to Nexus"
      docker push nexus:8082/msp-apple
      echo "FINISHED Pushing Apple Docker image to Nexus"
	  ;;

    Mango)
	  echo "STARTED Building Mango Docker image"
      docker build -t nexus:8082/msp-mango -f Dockerfile.Mango .
      echo "FINISHED Building Mango Docker image"

      echo "STARTED Pushing Mango Docker image to Nexus"
      docker push nexus:8082/msp-mango
      echo "FINISHED Pushing Mango Docker image to Nexus"
	  ;;
  esac
done

echo 
echo "Build script finished"
