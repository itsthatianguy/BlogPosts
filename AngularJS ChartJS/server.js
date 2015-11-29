// Basic static file server
// Returns the file, or index.html if looking at the root location
// Does not handle missing files as it stands

var http = require('http'),
    url = require('url'),
    path = require('path'),
    fs = require('fs');

var mimeTypes = {
    "html": "text/html",
    "jpeg": "image/jpeg",
    "jpg": "image/jpeg",
    "png": "image/png",
    "js": "text/javascript",
    "css": "text/css"};

http.createServer(function(req, res) {
    var uri = url.parse(req.url).pathname;
    var filename = path.join(process.cwd(), uri);
    var mimeType = mimeTypes[path.extname(filename).split(".")[1]];
    res.writeHead(200, mimeType);

    if (uri == "/") {
        fs.readFile('index.html',function(err, data){
        res.write(data);
        res.end();
    });
    }
    else {
        var fileStream = fs.createReadStream(filename);
        fileStream.pipe(res);
    }
}).listen(1337);