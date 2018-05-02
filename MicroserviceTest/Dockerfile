FROM microsoft/aspnetcore:2.0.3
# Dot Net files are published in the pub folder and copied to the app folder in the container
COPY pub/ /app/
WORKDIR /app

# DIRECTORY where the Microservice will generate logs
RUN mkdir -p /usr/local/LogFolder \
 && mkdir -p /var/log/supervisord \
 && mkdir -p /var/log/micro-service

# Specifying port for the Microservice
ENV ASPNETCORE_URLS="http://*:5020"
EXPOSE 5020/tcp

# Setting Time Zone on the container
ENV TZ=America/Chicago
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

# Directory to download Filebeat Package
WORKDIR /usr/local/filebeat

# CURL command to download Filebeat package
RUN curl -L -O https://artifacts.elastic.co/downloads/beats/filebeat/filebeat-6.2.4-amd64.deb
RUN dpkg -i filebeat-6.2.4-amd64.deb

# I am replacing the filebeat file inside the container with my local version
COPY filebeat.yml /etc/filebeat/filebeat.yml

# supervisor is being used to run multiple processes in the same container
RUN apt-get update && apt-get install -y supervisor

# I am copying the config file from the local machine inside the container
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf
ENTRYPOINT ["/usr/bin/supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf"]
