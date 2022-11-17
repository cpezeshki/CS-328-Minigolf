from bs4 import BeautifulSoup
import requests
handle = input('Input your account name on Twitter: ') 
temp = requests.get('https://twitter.com/'+handle)
bs = BeautifulSoup(temp.text,'lxml')
try:
    follow_box = bs.find('li',{'class':'ProfileNav-item ProfileNav-item--followers'})
    followers = follow_box.find('a').find('span',{'class':'ProfileNav-value'})
    print("Number of followers: {} ".format(followers.get('data-count')))
except:
    print('Account name not found...')