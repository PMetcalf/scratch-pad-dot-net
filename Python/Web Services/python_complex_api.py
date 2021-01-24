'''
Python Complex API

Workiing with a RESTful API with authentication, rate limiting and pagination.
'''

# Module Imports
import requests

# Constants
APPLICATION_NAME = "API Sandbox App"
API_KEY = "ad927174be69fdf7dbe167638cbc1184"
REGISTERED_TO = "paul_metcalf_uk"
USER_AGENT = "CloudforestTech"
last_fm_url = "http://ws.audioscrobbler.com/2.0/"

headers = {
    'user-agent': USER_AGENT
}

payload = {
    'api_key': API_KEY,
    'method': 'chart.gettopartists',
    'format': 'json'
}

response = requests.get(last_fm_url, headers = headers, params = payload)

print(response.status_code)