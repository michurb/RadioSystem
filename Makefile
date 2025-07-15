.PHONY: build test run docker-build docker-run

build:
	dotnet build

test:
	dotnet test

run:
	dotnet run --project src/RadioSchedulingSystem.Api

docker-build:
	docker build -t radio-scheduling-system -f src/RadioSchedulingSystem.Api/Dockerfile .


docker-run:
	docker build -t radio-scheduling-system -f src/RadioSchedulingSystem.Api/Dockerfile .