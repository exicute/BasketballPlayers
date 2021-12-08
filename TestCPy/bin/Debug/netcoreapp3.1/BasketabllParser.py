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
    for url in urls:
        teamUrl_req = requests.get(URL+url)
        
        tree = html.fromstring(teamUrl_req.content)
        team_name = tree.xpath('//*[@id="meta"]/div[2]/h1/span[2]/text()')
        table = tree.xpath('//*[@id="totals"]')

        pd_tables = pd.read_html(html.tostring(table[0], method='html'))
        pd_table = pd_tables[0]

        for name in team_name:
            name_list = name.split()
            if len(name_list)>2:
                fName = name_list[0]
                sName = name_list[1]
                thName = name_list[2]
            else:
                fName = name_list[0]
                sName = name_list[1]
                thName = "_"
            pd_table.to_excel('Players/{}_{}_{}.xlsx'.format(fName, sName, thName), sheet_name='stats', index=False)

            



if __name__ == '__main__':
    URL = 'https://www.basketball-reference.com/'
    req = requests.get(URL)

    get_table(URL, teams_urls(req))
