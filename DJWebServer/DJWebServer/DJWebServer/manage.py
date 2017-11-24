#!/usr/bin/env python
"""
Command-line utility for administrative tasks.
"""

import os
import sys
from django.core.management import execute_from_command_line
import json

from DJWebServer.udpcontrol import UdpControl

if __name__ == "__main__":

	

	os.environ.setdefault(
        "DJANGO_SETTINGS_MODULE",
        "DJWebServer.settings"
    )
	

	
	Name_Test.objects.create(Name='小明', Age='11')

	udp = UdpControl()
	udp.ConnectUdp()
	udp.SendCheck('192.168.1.1')
    #execute_from_command_line(sys.argv)


	while True:
		print ('thread_main wait for recv:')
		data, addr = udp.s.recvfrom(512)

		jsonstr = data.decode()
		jsondata = json.loads(jsonstr)
		cmd = jsondata['cmd']
		ip = jsondata['ip']

		print ('thread_main recv cmd :' + cmd + ' ip: ' + ip   + str(addr))