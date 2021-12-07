# Derived from official mysql image (our base image)
FROM mysql

# Add a database
ENV MYSQL_DATABASE gametimecm2
ENV MYSQL_ROOT_PASSWORD=gametimecm2

# Add the content of the cripts/ directory to your image
# All scripts in docker-entrypoint-initdb.d/ are automatically
# executed during container startup
COPY ./scripts/ /docker-entrypoint-initdb.d/