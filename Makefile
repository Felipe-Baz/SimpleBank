.PHONY: start tests

tests:
	dotnet test

start: tests
	docker compose -f src/simplebank/docker-compose.yml build
	docker compose -f src/simplebank/docker-compose.yml up -d
	dotnet ef database update --project src/simplebank