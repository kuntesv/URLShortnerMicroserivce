## Get Orignal URL

This API allows caller to get orignal long url , when caller provides the short url. If short URL is not present then call will recive error.

### HTTP Request

```
POST /api/Url/getOrignalUrl
```

##### **Request Body**

#### Scenario 1 : Valid Input
This request will be sent for shortURL present into Database , user will recive the valid long URL.

```json
{
  "shortUrl": "newgen.lyKiQtwU"
}
```

### HTTP Response

#### **Success**
```json
{
    "message": null,
    "longUrl": "https://www.perplexity.ai/search/add-summar-to-method-public-as-e5ChHo6lR0OgFARqN4p8Uw",
    "shortUrl": "newgen.lyKiQtwU"
}
```



