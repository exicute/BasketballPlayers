from lxml import etree
from lxml import html
import requests
import pandas as pd


def teams_urls(req):
    eastConf = []
    westConf = []
    
    tree = html.fromstring(req.content)
    for num in range(1, 16):
        teamUrl = tree.xpath('//*[@id="confs_standings_E"]/tbody/tr[{}]/th/a'.format(num))
        for attr in teamUrl:
            eastConf.append(attr.attrib['href'])

    for num in range(1, 16):
        teamUrl = tree.xpath('//*[@id="confs_standings_W"]/tbody/tr[{}]/th/a'.format(num))
        for attr in teamUrl:
            westConf.append(attr.attrib['href'])

    return eastConf+westConf


def get_table(URL, urls):
    teamColumns = []
    req = requests.get(URL+urls[0])
    tree = html.fromstring(req.content)
    for num in range(1, 28):
        stat_name = tree.xpath('//*[@id="totals"]/thead/tr/th[{}]/@data-stat'.format(num))
        teamColumns.append(stat_name)

    for x in range(len(teamColumns)):
        for y in teamColumns[x]:
            teamColumns[x] = y




if __name__ == '__main__':
    URL = 'https://www.basketball-reference.com/'
    req = requests.get(URL)

    get_table(URL, teams_urls(req))

#    with open('players/PlayersStats/Atlanta.txt', 'w') as input_file:
#        for item in teams_urls(req):
#            input_file.write((html.tostring(item)).decode('utf-8'))
