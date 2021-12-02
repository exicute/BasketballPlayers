from lxml import etree
from lxml import html
import requests


URL = 'https://www.basketball-reference.com/teams/BRK/2022.html'
req = requests.get(URL)

tree = html.fromstring(req.content)
with open('Atlanta.txt', 'w') as input_file:
    for item in tree.xpath('//*[@id="meta"]/div[2]/h1'):
        input_file.write((html.tostring(item)).decode('utf-8'))
