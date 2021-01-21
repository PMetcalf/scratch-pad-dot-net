'''
Python RESTful API

RESTful API sandbox with request module.
'''

# Module Imports
import requests

# Make a request to an URL that doesn't exist
url = "http://api.open-notify.org/this-api-doesnt-exist"

response = requests.get(url)

print(response.status_code)