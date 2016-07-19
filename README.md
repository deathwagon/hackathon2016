# hackathon2016

## To get the container running with cassandra

        docker-compose build
        docker-compose up -d
        docker exec cassandra cqlsh -f /var/www/.docker/cql/create_keyspace.cql
        docker exec cassandra cqlsh -f /var/www/.docker/cql/create_tables.cql
        docker exec cassandra cqlsh -f /var/www/.docker/cql/insert_data.cql

## When you are done, you tear it down like this

        docker-compose down

