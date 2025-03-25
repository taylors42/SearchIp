# 📝 IP Location Search Tool

A .NET console application that retrieves geographical information for IP addresses using the IP-API service.

## 🎯Features

* CLI interface with simple argument parsing
* JSON response parsing
* Error handling for invalid IPs and API failures
* Clean console output formatting

## ✨ Implementadas

- [ ] -h User manual /Help
- [ ] -l Return location
- [ ] -i Return ISP (internet provider)
- [ ] -c Return the city
- [ ] -st Return the state
- [ ] -m Returns geographic information based on your IP
- [ ] -ip Return your own IP
- [ ] -s Checks if the IP is on a safe list
- [ ] -p Open ports on IP

## 🔧 Installation

### . Windows

```bash
git clone https://github.com/taylors42/SearchIp
cd SearchIp
dotnet build
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true

// set to the path

setx PATH "%PATH%;C:\Users\User\path"
```

### . Linux

```bash
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true
```

# 📝 Usage

```bash
searchip ip-address
# Example:
searchip 0.0.0.0
```

# 📝 Build from Source

1. Install [.NET SDK](https://dotnet.microsoft.com/download)

2. Clone repository

3. Build project:
   
   ```bash
   dotnet build
   ```

# 📝Output Format

Successful lookup:

```
Country: Brazil, Region: São Paulo, City: Diadema, ISP: Claro
```

Failed lookup:

```
dont find
```

# 📝 API Documentation

Check out [IP-API](http://ip-api.com/docs)
