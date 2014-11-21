In-Class-A02
============

This repo is a working draft of example(s) given in-class. *This repository will be deleted at the end of the term.*

## Tip for Web.Config
Do you find yourself having to switch between using `Data Source=.` and `Data Source=.\SQLEXPRESS` because you only have SQL Express on your home computer? If you do, and you are using version control with a team, chances are you will eventually have a merge conflict as your team members are needing different versions of your web.config file.

On your local machine, you can tell git to ignore changes to your file by running the following command in your git shell:

```
git update-index --assume-unchanged "path/to/web.config"
```

For more details, check out [this blog post](http://archive.robwilkerson.org/2010/03/02/git-tip-ignore-changes-to-tracked-files/).
