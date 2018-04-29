FROM microsoft/aspnetcore:2.0.3
COPY pub/ /app/
WORKDIR /app

RUN mkdir -p /usr/local/VAS

ENV ASPNETCORE_URLS="http://*:5020"
EXPOSE 5020/tcp

WORKDIR /usr/local/filebeat

RUN curl -L -O https://artifacts.elastic.co/downloads/beats/filebeat/filebeat-6.2.4-amd64.deb
RUN dpkg -i filebeat-6.2.4-amd64.deb

RUN apt-get update && apt-get install -y supervisor
RUN mkdir -p /var/log/supervisor
COPY supervisord.conf /etc/supervisor/conf.d/supervisord.conf
ENTRYPOINT ["/usr/bin/supervisord", "-c", "/etc/supervisor/conf.d/supervisord.conf"]

#WORKDIR /usr/local/app

#ADD docker-entrypoint.sh /usr/local/app/

#RUN ["chmod", "+x", "/usr/local/app/docker-entrypoint.sh"]

#ENTRYPOINT ["/usr/local/app/docker-entrypoint.sh"]
#CMD service filebeat start