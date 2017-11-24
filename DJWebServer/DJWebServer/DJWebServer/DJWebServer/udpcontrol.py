from socket import *
import json
import threading


def thread_main():
	while True:
		print ('thread_main wait for recv:')
		data, addr = gsock.recvfrom(512)
		print ('thread_main recv:' + data + ' ' + addr)

class UdpControl:
	def __init__ (self):
		print ('udpcontrol init')

	def ConnectUdp(self):
		self.HOST='127.0.0.1'

		self.PORT=6000
		self.ServerPORT=5000

		self.s = socket(AF_INET,SOCK_DGRAM)
		self.s.bind((self.HOST,self.PORT))

		
		print ('udpcontrol connected')

		global gsock
		gsock = self.s

		#t = threading.Thread(target=thread_main, args=())
		#t.start()

	def SendCheck(self,ip): 
		data = {
		'cmd' : 'check',
		'ip' : ip,
		}
		json_str = json.dumps(data)

		self.s.sendto(json_str.encode(),(self.HOST,self.ServerPORT))



	def Disconnect():
		self.s.close()



	


