# hackathon2016

## To get the container running

        docker-compose build
        docker-compose up -d
        docker exec cassandra cqlsh -f /var/www/.docker/cql/create_keyspace.cql
        docker exec cassandra cqlsh -f /var/www/.docker/cql/create_tables.cql
        docker exec cassandra cqlsh -f /var/www/.docker/cql/insert_data.cql
        
## Quick checks to makes sure everything is running

        // Show running docker machines
        docker-machine ls

        // Show processes running that were started by docker-compose
        docker-compose ps

## When you are done, you tear it down like this

        docker-compose down

## Local Cassandra

        //CQLSH_HOST=[docker_machine_ip] cqlsh
        CQLSH_HOST=192.168.99.100 cqlsh
        cqlsh> SELECT * FROM seo.applications;

## Local Web Apps

        // SEO API
        http://192.168.99.100:5002/seo/v1/application
        
        // SEO Editor
        http://192.168.99.100:5001/
        
        // Consuming Web Application
        http://192.168.99.100:5280/websites/website-builder?market=es-ES
