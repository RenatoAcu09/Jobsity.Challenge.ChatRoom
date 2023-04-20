# ChatRoom

## Mandatory Features
- Allow registered users to log in and talk with other users in a chatroom.
- Allow users to post messages as commands into the chatroom with the following format /stock=stock_code
- Create a decoupled bot that will call an API using the stock_code as a parameter (https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv, here aapl.us is the stock_code)
- The bot should parse the received CSV file and then it should send a message back into the chatroom using a message broker like RabbitMQ. The message will be a stock quote using the following format: “APPL.US quote is $93.42 per share”. The post owner will be the bot.
- Have the chat messages ordered by their timestamps and show only the last 50 messages.
- Unit test the functionality you prefer.

## Bonus 
- Have more than one chatroom.
- Use .NET identity for users authentication
- Handle messages that are not understood or any exceptions raised within the bot.


## Requirements
You must have *docker* installed on your operating system (Linux, Windows or Mac).  

# Steps to run the application

*Obs.: Navigate the folder until you reach the project' folder.*

### Run the command:
- ` docker-compose up --build` 

### After that , access http://localhost:8080 into a web-browser and start to using the Chat.


## To debug the application

1. Run the following commands to start RabbitMQ and MySQL:  
    - `docker run -d -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.9-management`  
    - `docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=DockerSql2019!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU15-ubuntu-20.04`
1. Open the solution with Visual Studio  
2. Right-click into the Solution -> `Properties`  
3. Check `Multiple startup projects` then set as bellow:  
![image](https://user-images.githubusercontent.com/68758262/233169233-7a53f754-9ecb-4f6a-921f-1554b221a7e7.png)
4. Click on `► Start`  

## Preview

![image](https://user-images.githubusercontent.com/68758262/233257696-c44b4a11-dcbd-4546-a40e-26e1e4e17a26.png)

