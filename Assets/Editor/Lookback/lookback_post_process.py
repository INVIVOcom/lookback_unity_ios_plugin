# lookback_post_process.py
# lookback_unity_ios_plugin
# Author: Andrew Lee
# Copyright (C) 2015 INVIVO Communications Inc.
import os
import sys
from sys import argv

sys.path.insert(0, os.getcwd() + "/Assets/Editor/Lookback/mod-pbxproj/mod_pbxproj")

from mod_pbxproj import XcodeProject

path = argv[1]

print('opening project: ' + path + '/Unity-iPhone.xcodeproj/project.pbxproj')

project = XcodeProject.Load(path + '/Unity-iPhone.xcodeproj/project.pbxproj')

print('adding frameworks')
project.add_framework_search_paths("lookback/HD", False)
project.add_framework_search_paths("lookback/Safe", False)

project.add_other_ldflags("-ObjC -framework Lookback")

if project.modified:
    project.backup()
    project.saveFormat3_2()

print('done')
