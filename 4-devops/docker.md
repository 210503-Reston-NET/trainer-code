# Building your docker image from a docker file

1. Navigate to the directory that contains your docker file
2. In bash run `docker build -t <user-friendly-image-name> .` or `docker build -t <dockerhub-username>/<reponame>:tagname .`
3. If the build passes good job!

# Running your docker image in a container

1. Check if the image you want to run is available by executing `docker images`
2. In bash run `docker run -t <image name>` or `docker run -p exposed-port:80 -t <image name>` for webapps
3. If all goes well, go to localhost:<exposed-port> to view your deployed webapp

# Publishing docker images to docker hub

1. check if you're logged in using the command `docker login`
   - if you're not logged in, log in
2. retag the image you want to publish using the command: `docker build -t <dockerhub-username>/<reponame>:tagname .`
3. push it to dockerhub by running the command: `docker push <dockerhub-username>/<reponame>:tagname`

# Snake docker

## Snake from an image on dockerhub

`docker pull aschil/snake`
`docker run -p HostPort:8080 -t aschil/snake`

## Snake on the terminal

```
mkdir snakedocker
cd snakedocker
nano Dockerfile

FROM ubuntu:18.04
RUN apt-get update && apt-get install -y libncurses5-dev && apt-get install -y nsnake
CMD ["/usr/games/nsnake"]

docker build -t snake:auto .

docker run -it snake:auto
```
