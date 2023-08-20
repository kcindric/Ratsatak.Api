# build image from docker file
docker build -t ratsatak-api-arm .

# save local image to .tar file for copy/paste to RPI
docker save -o docker-ratsatak-api-arm-image.tar ratsatak-api-arm

# copy files from PC to RPI
scp -r docker-ratsatak-api-arm-image.tar root@192.168.0.100:/root/files

# load .tar image to docker
docker load < docker-ratsatak-api-arm-image.tar

# build Ratsatak api from ARM image
docker run -d -p 5263:80 -v ratsatak_data:/app/data --name ratsatak-api ratsatak-api-arm

# gluetun
- install gluetun with OpenVPN
- set all contianers network to container --> gluetun, remove ports and expose them through gluetun container
- watch-out if gluetun restarts, the you need to update again the network in the other containers
- connection strings should be 'localhost' because they are in the gluetun network and i.e. 192.168.0.100 won't be accessible