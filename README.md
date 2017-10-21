# elasticsearch-asp.net-mvc
This application is a sample for Elasticsearch client with ASP.Net MVC and Bootstrap.

## Features
* MultiMatchQuery
* Hightlight
* Paginated

## Requirements
* .Net Framework 4.5 or higher
* Elasticsearch requires 5.5 or higher

## Installation
* [Download](https://www.elastic.co/downloads/elasticsearch) and unzip the Elasticsearch official distribution.
* Run bin\elasticsearch
* Run curl -X GET http://localhost:9200/
* [Sampe data](https://github.com/junglestory/scrape_blog_crawler)

## Soruce code clone
git clone https://github.com/junglestory/elasticsearch-asp.net-mvc.git
<pre><code>
$ cd elasticsearch-asp.net-mvc
</code></pre>

## Configuration
* web.config
<pre><code>
&lt;appSettings&gt;
    &lt;add key="SearchServer" value="http://localhost" /s&gt; // your host
    &lt;add key="SearchPort" value="9200" /s&gt; // search port
    &lt;add key="ListCount" value="10" /s&gt; 
&lt;/appSettingss&gt;
</code></pre>

## Run
http://localhost:1279/
