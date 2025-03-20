

```markdown
# IP Location Search Tool

A .NET console application that retrieves geographical information for IP addresses using the IP-API service.

## Features
- CLI interface with simple argument parsing
- JSON response parsing
- Error handling for invalid IPs and API failures
- Clean console output formatting

## Installation
```bash
git clone https://github.com/taylors42/SearchIp
cd SearchIp
dotnet build
dotnet dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true
```

## Usage
```bash
searchip ip-address
# Example:
searchip 0.0.0.0
```

## Build from Source
1. Install [.NET SDK](https://dotnet.microsoft.com/download)
2. Clone repository
3. Build project:
```bash
dotnet build
```

## Output Format
Successful lookup:
```
Country: Brazil, Region: São Paulo, City: Diadema, ISP: Claro
```

Failed lookup:
```
dont find
```

## API Documentation
Check out [IP-API](http://ip-api.com/docs)