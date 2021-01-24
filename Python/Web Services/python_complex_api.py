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
last_fm_url = "http://my-api-url"

headers = {
    'user-agent': 'CloudforestTech'
}

response = requests.get(last_fm_url, headers = headers)