"""
Definition of models.
"""

from django.db import models

# Create your models here.
class Name_Test(models.Model):   #对应数据库中的数据表 “表名”
    Name = models.CharField(max_length=200)  # 对应 “字段名”
    Age = models.IntegerField(blank=True, null=True)




class SensorData(models.Model):
    device = models.CharField(max_length=128)  # 对应 “字段名”
    timestamp = models.IntegerField(blank=False, null=False)
    sensorvalue = models.IntegerField(blank=False, null=False)
    remarks = models.CharField(max_length=256,blank = True,null=False)  # 对应 “字段名”
    class Meta:
        permissions = (
            ("control_terminal", "Can control terminal"),
            ("see_terminal", "Can see terminaldata"),
        )
