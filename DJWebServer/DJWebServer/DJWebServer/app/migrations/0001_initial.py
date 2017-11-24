# -*- coding: utf-8 -*-
# Generated by Django 1.11.7 on 2017-11-24 02:15
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Name_Test',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('Name', models.CharField(max_length=200)),
                ('Age', models.IntegerField(blank=True, null=True)),
            ],
        ),
        migrations.CreateModel(
            name='SensorData',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('device', models.CharField(max_length=128)),
                ('timestamp', models.IntegerField()),
                ('sensorvalue', models.IntegerField()),
                ('remarks', models.CharField(blank=True, max_length=256)),
            ],
            options={
                'permissions': (('control_terminal', 'Can control terminal'), ('see_terminal', 'Can see terminaldata')),
            },
        ),
    ]
