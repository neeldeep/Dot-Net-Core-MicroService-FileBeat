FROM microsoft/aspnetcore:2.0.3
COPY pub/ /app/
WORKDIR /app

# DIRECTORY where the Microservice will generate logs
RUN mkdir -p /usr/local/VAS \
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

RUN curl -L -O https://artifacts.elastic.co/downloads/beats/filebeat/filebeat-6.2.4-amd64.deb
RUN dpkg -i filebeat-6.2.4-amd64.deb

COPY filebeat.yml /etc/filebeat/filebeat.yml

# supervisor is being used to run multiple processes in the same container
RUN apt-get update && apt-get install -y supervisor

COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf
ENTRYPOINT ["/usr/bin/supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf"]


#WORKDIR /usr/local/app

#ADD docker-entrypoint.sh /usr/local/app/

#RUN ["chmod", "+x", "/usr/local/app/docker-entrypoint.sh"]

#ENTRYPOINT ["/usr/local/app/docker-entrypoint.sh"]
#CMD service filebeat start