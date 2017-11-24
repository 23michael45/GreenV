"""
Definition of views.
"""

from django.shortcuts import render
from DJWebServer.udpcontrol import UdpControl
from app.models import Name_Test
from django.http import HttpRequest
from django.template import RequestContext
from datetime import datetime
from django.http import HttpResponse 
import time

def home(request):
	

	
	Name_Test.objects.create(Name='小明', Age='11')
	
	"""Renders the home page."""
	assert isinstance(request, HttpRequest)
	return render(
        request,
        'app/index.html',
        {
            'title':'Home Page',
            'year':datetime.now().year,
        }
    )

def contact(request):
    """Renders the contact page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'app/contact.html',
        {
            'title':'Contact',
            'message':'Your contact page.',
            'year':datetime.now().year,
        }
    )

def about(request):
    """Renders the about page."""
    assert isinstance(request, HttpRequest)
    return render(
        request,
        'app/about.html',
        {
            'title':'About',
            'message':'Your application description page.',
            'year':datetime.now().year,
        }
    )
def djangotutorial(request):
	return render(request,'app/django-tutorial.html')

def click(request):

	name=request.GET.get('name1') # 获取参数值
	ans={}
	ans['head']='hello,'+name # 运算处理
	return render(request,'app/index.html',ans)


def asktime(request):    

	q=request.GET.get('paramname') # 获取参数名为name的参数值
	ans= q + ' ' +  time.strftime('%Y-%m-%d %H:%M.%S',time.localtime(time.time()))

   # 获取当前时间
	return HttpResponse(ans)